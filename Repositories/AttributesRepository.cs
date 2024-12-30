using InventoryManagementaAPI.Interfaces;
using InventoryManagementaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementaAPI.Repositories
{
	public class AttributesRepository : IAttributesRepository
	{
		protected readonly InventoryContext _context;

		public AttributesRepository(InventoryContext context)
		{
			_context = context;
		}

		public async Task<List<Attributes>> GetAllAttributes()
		{
			List<Attributes> attributes;
			try
			{
				attributes = await _context.Attributes.ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(attributes);
		}

		public async Task<List<AttributeValues>> GetAllAttributeValues()
		{
			List<AttributeValues> attributeValues;
			try
			{
				attributeValues = await _context.AttributeValues.ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(attributeValues);
		}

		public async Task<bool> Post(Attributes attribute)
		{
			bool result;
			try
			{
				_context.Attributes.Add(attribute);
				int response = await (_context.SaveChangesAsync());
				result = response == 1;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		public async Task<bool> Post(AttributeValues attributeValue)
		{
			bool result;
			try
			{
				_context.AttributeValues.Add(attributeValue);
				int response = await (_context.SaveChangesAsync());
				result = response == 1;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		public async Task<bool> DeleteAttribute(Guid ID)
		{
			bool result = false;
			try
			{
				if (await DeleteAllAttributeValues(ID) == true)
				{

					var attribute = await _context.Attributes.FindAsync(ID);
					_context.Attributes.Remove(attribute!);
					var response = await _context.SaveChangesAsync();
					result = response == 1;
				}
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result);
		}

		public async Task<bool> DeleteAttributeValue(Guid AttributeValueId)
		{
			bool result;
			try
			{
				var attribute = await _context.AttributeValues.FindAsync(AttributeValueId);
				_context.AttributeValues.Remove(attribute!);
				var response = await _context.SaveChangesAsync();
				result = response == 1;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		public async Task<bool> DeleteAllAttributeValues(Guid AttributeId)
		{
			bool result;
			try
			{
				var attributes = await _context.AttributeValues.Where(w => w.AttributeId == AttributeId).ToListAsync();
				_context.AttributeValues.RemoveRange(attributes);
				var response = await _context.SaveChangesAsync();
				result = response == attributes.Count || attributes.Count == 0;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}
	}
}

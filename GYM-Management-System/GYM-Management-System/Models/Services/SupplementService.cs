using GYM_Management_System.Data;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM_Management_System.Models.Services
{
    /// <summary>
    /// Service class for managing supplements.
    /// </summary>
    public class SupplementService : ISupplement
    {
        private readonly GymDbContext _supplement;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplementService"/> class.
        /// </summary>
        /// <param name="supplement">The database context for supplements.</param>
        public SupplementService(GymDbContext supplement)
        {
            _supplement = supplement;
        }

        /// <summary>
        /// Creates a new supplement.
        /// </summary>
        /// <param name="supplementDTO">The supplement data to create.</param>
        /// <returns>The created supplement data.</returns>
        public async Task<SupplementDTO> CreateSupplement(CreatSupplementDTO supplementDTO)
        {
            try
            {
                var newSupplement = new Supplement()
                {
                    Name = supplementDTO.Name,
                    Price = supplementDTO.Price,
                    Description = supplementDTO.Description,
                };

                _supplement.Entry(newSupplement).State = EntityState.Added;
                await _supplement.SaveChangesAsync();

                var SupplementDtoReturn = new SupplementDTO()
                {
                    SupplementID = newSupplement.SupplementID,
                    Name = newSupplement.Name,
                    Price = newSupplement.Price,
                    Description = newSupplement.Description,
                };

                return SupplementDtoReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the supplement.", ex);
            }
        }

        /// <summary>
        /// Deletes a supplement by ID.
        /// </summary>
        /// <param name="supplementId">The ID of the supplement to delete.</param>
        /// <returns>True if the supplement was successfully deleted; otherwise, false.</returns>
        public async Task<bool> DeleteSupplement(int supplementId)
        {
            var deletedSupplement = await _supplement.Supplements.FindAsync(supplementId);
            if (deletedSupplement != null)
            {
                _supplement.Supplements.Remove(deletedSupplement);
                await _supplement.SaveChangesAsync();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retrieves all supplements.
        /// </summary>
        /// <returns>A list of supplements.</returns>
        public async Task<List<SupplementDTO>> GetAllSupplements()
        {
            try
            {
                var supplements = await _supplement.Supplements
                    .Select(t => new SupplementDTO
                    {
                        SupplementID = t.SupplementID,
                        Name = t.Name,
                        Price = t.Price,
                        Description = t.Description,
                    }).ToListAsync();

                return supplements;
            }
            catch (Exception ex)
            {
                return new List<SupplementDTO>();
            }
        }

        /// <summary>
        /// Retrieves a supplement by ID.
        /// </summary>
        /// <param name="supplementId">The ID of the supplement to retrieve.</param>
        /// <returns>The supplement data.</returns>
        public async Task<SupplementDTO> GetSupplementById(int supplementId)
        {
            try
            {
                var supplement = await _supplement.Supplements
                    .Select(t => new SupplementDTO
                    {
                        SupplementID = t.SupplementID,
                        Name = t.Name,
                        Price = t.Price,
                        Description = t.Description,
                    }).FirstOrDefaultAsync(sp => sp.SupplementID == supplementId);

                return supplement;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Updates a supplement by ID.
        /// </summary>
        /// <param name="supplementId">The ID of the supplement to update.</param>
        /// <param name="updatedSupplementDTO">The updated supplement data.</param>
        /// <returns>The updated supplement data, or null if the supplement was not found.</returns>
        public async Task<SupplementDTO> UpdateSupplement(int supplementId, CreatSupplementDTO updatedSupplementDTO)
        {
            try
            {
                Supplement updatedSupplement = await _supplement.Supplements.FindAsync(supplementId);

                if (updatedSupplement != null)
                {
                    updatedSupplement.Name = updatedSupplementDTO.Name;
                    updatedSupplement.Price = updatedSupplementDTO.Price;
                    _supplement.Entry(updatedSupplement).State = EntityState.Modified;
                    await _supplement.SaveChangesAsync();

                    SupplementDTO supplementDTO = new SupplementDTO()
                    {
                        SupplementID = supplementId,
                        Name = updatedSupplementDTO.Name,
                        Price = updatedSupplementDTO.Price,
                        Description = updatedSupplementDTO.Description,
                    };
                    return supplementDTO;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

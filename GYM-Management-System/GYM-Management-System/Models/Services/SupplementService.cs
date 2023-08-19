using GYM_Management_System.Data;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GYM_Management_System.Models.Services
{
    public class SupplementService : ISupplement
    {
        private readonly GymDbContext _supplement;
        public SupplementService(GymDbContext supplement)
        {
            _supplement = supplement;
        }

        public async Task<SupplementDTO> CreateSupplement(CreatSupplementDTO supplementDTO)
        {
            try
            {
                var newSupplement = new Supplement()
                {
                    Name = supplementDTO.Name,
                    Price = supplementDTO.Price,
                };

                _supplement.Entry(newSupplement).State = EntityState.Added;
                await _supplement.SaveChangesAsync();

                var SupplementDtoReturn = new SupplementDTO()
                {
                    SupplementID = newSupplement.SupplementID,
                    Name = newSupplement.Name,
                    Price = newSupplement.Price,
                };

                return SupplementDtoReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the supplement.", ex);
            }
        }


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

                    }).ToListAsync();

                return supplements;
            }
            catch (Exception ex)
            {
                return new List<SupplementDTO>();
            }
        }


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

                    }).FirstOrDefaultAsync(sp => sp.SupplementID == supplementId);

                return supplement;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


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

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

        public async Task<SupplementDTO> CreateSupplement(SupplementDTO supplementDTO)
        {
            var newSupplement = new Supplement()
            {
                SupplementID = supplementDTO.SupplementID,
                Name = supplementDTO.Name,
                Price = supplementDTO.Price,

            };
            _supplement.Entry(newSupplement).State = EntityState.Added;
            await _supplement.SaveChangesAsync();
            supplementDTO.SupplementID = newSupplement.SupplementID;

            return supplementDTO;

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
            return await _supplement.Supplements
                .Select(t => new SupplementDTO
                {
                    SupplementID = t.SupplementID,
                    Name = t.Name,
                    Price = t.Price,

                }).ToListAsync();
        }

        public async Task<SupplementDTO> GetSupplementById(int supplementId)
        {
            return await _supplement.Supplements
                .Select(t => new SupplementDTO
                {
                    SupplementID = t.SupplementID,
                    Name = t.Name,
                    Price = t.Price,

                }).FirstOrDefaultAsync(sp => sp.SupplementID == supplementId);
        }

        public async Task<Supplement> UpdateSupplement(int supplementId, SupplementDTO updatedSupplementDTO)
        {
            var updatedSupplement = await _supplement.Supplements.FindAsync(supplementId);

            if (updatedSupplement != null)
            {

                updatedSupplement.Name = updatedSupplementDTO.Name;
                updatedSupplement.Price = updatedSupplementDTO.Price;

                await _supplement.SaveChangesAsync();

            }

            return updatedSupplement;
        }
    }
}

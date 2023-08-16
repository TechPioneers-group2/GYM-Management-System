using GYM_Management_System.Data;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GYM_Management_System.Models.Services
{
    public class GymSupplementService : IGymSupplement
    {
        private readonly GymDbContext _gymSupplement;

        public GymSupplementService(GymDbContext gymSupplement)
        {
            _gymSupplement = gymSupplement;
        }


        public async Task<PostGymSupplementDTO> CreateGymSupplement(int gymId, int supplementId, PostGymSupplementDTO gymSupplementDTO)
        {
            var gym = await _gymSupplement.Gyms.FindAsync(gymId);
            var supplement = await _gymSupplement.Supplements.FindAsync(supplementId);


            if (gym == null || supplement == null)
            {
                return null;
            }


            var gymSupplement = new GymSupplement
            {
                GymID = gymSupplementDTO.GymID,
                SupplementID = gymSupplementDTO.SupplementID,
                Quantity = gymSupplementDTO.Quantity
            };

            _gymSupplement.GymSupplements.Add(gymSupplement);
            await _gymSupplement.SaveChangesAsync();


            gymSupplementDTO.GymID = gymSupplement.GymID;
            gymSupplementDTO.SupplementID = gymSupplement.SupplementID;

            return gymSupplementDTO;
        }

        public async Task<bool> DeleteGymSupplement(int gymId, int supplementId)
        {
            var gymSupplement = await _gymSupplement.GymSupplements
                   .FirstOrDefaultAsync(gs => gs.GymID == gymId && gs.SupplementID == supplementId);

            if (gymSupplement == null)
            {
                return false;
            }

            _gymSupplement.GymSupplements.Remove(gymSupplement);
            await _gymSupplement.SaveChangesAsync();

            return true;
        }

        public async Task<List<GetGymSupplementDTO>> GetAllGymSupplements(int gymId)
        {
            return await _gymSupplement.GymSupplements
                .Where(g => g.GymID == gymId)
                .Select(gs => new GetGymSupplementDTO()
                {
                    GymID = gs.GymID,
                    SupplementID = gs.SupplementID,
                    Quantity = gs.Quantity,
                    Supplement = new GetSupplementDTO()
                    {
                        SupplementID = gs.Supplement.SupplementID,
                        Name = gs.Supplement.Name,
                        Price = gs.Supplement.Price

                    }
                }
                ).ToListAsync();
        }

        public async Task<GetGymSupplementDTO> GetGymSupplementById(int gymId, int supplementId)
        {
            return await _gymSupplement.GymSupplements
               .Where(g => g.GymID == gymId)
               .Select(gs => new GetGymSupplementDTO()
               {
                   GymID = gs.GymID,
                   SupplementID = gs.SupplementID,
                   Quantity = gs.Quantity,
                   Supplement = new GetSupplementDTO()
                   {
                       SupplementID = gs.Supplement.SupplementID,
                       Name = gs.Supplement.Name,
                       Price = gs.Supplement.Price

                   }
               }
               ).FirstOrDefaultAsync(gg => gg.SupplementID == supplementId);
        }

        public async Task<PostGymSupplementDTO> UpdateGymSupplement(int gymId, int supplementId, PostGymSupplementDTO updatedGymSupplementDTO)
        {

            var currentGymSupplement = await _gymSupplement.GymSupplements
                                                    .FindAsync(gymId, supplementId);

            if (currentGymSupplement != null)
            {

                currentGymSupplement.Quantity = updatedGymSupplementDTO.Quantity;


                await _gymSupplement.SaveChangesAsync();

                return updatedGymSupplementDTO;
            }

            return null;
        }
    }
}

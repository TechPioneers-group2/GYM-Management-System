﻿using GYM_Management_System.Models.DTOs;

namespace GYM_Management_System.Models.Interfaces
{
    public interface ISupplement
    {
        // Create a Supplement
        Task<SupplementDTO> CreateSupplement(SupplementDTO supplementDTO);

        // GET All Supplements
        Task<List<SupplementDTO>> GetAllSupplements();

        // GET Supplement By ID
        Task<SupplementDTO> GetSupplementById(int supplementId);

        // Update Supplement Data
        Task<Supplement> UpdateSupplement(int supplementId, SupplementDTO supplement);

        // Delete Supplement
        Task<bool> DeleteSupplement(int supplementId);
    }
}

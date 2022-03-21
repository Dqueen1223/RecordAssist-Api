using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Catalyte.Apparel.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the Patient repository.
    /// </summary>
    public class PatientRepository : IPatientRepository
    {
        private readonly IApparelCtx _ctx;

        public PatientRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }
        public async Task<Patient> GetPatientByIdAsync(int PatientId)
        {
            return await _ctx.Patients.FindAsync(PatientId);
        }
        public async Task<Patient> NoTrackingGetPatientByIdAsync(int PatientId)
        {
            return await _ctx.Patients.Where(p => p.Id == PatientId).AsNoTracking().Take(1).FirstOrDefaultAsync();
        }

        //public async Task<List<string>> GetAllUniquePatientCategoriesAsync()
        //{
        //    return await _ctx.Patients.Select(l => l.Category).Distinct().ToListAsync();
        //}

        //public async Task<List<string>> GetAllUniquePatientTypesAsync()
        //{
        //    return await _ctx.Patients.Select(l => l.Type).Distinct().ToListAsync();
        //}

        //public async Task<int> GetPatientsCountAsync(Nullable<bool> active, List<string> brand, List<string> category,
        //                                                                 List<string> color, List<string> demographic, List<string> material,
        //                                                                 decimal minPrice, decimal maxPrice, List<string> type, int? range, int returnPatients)
        //{
        //    return await _ctx.Patients.Where(p =>
        //    (p.Active == active || active == null) &&
        //    (brand.Contains(p.Brand.ToLower()) || brand.Count() == 0) &&
        //    (category.Contains(p.Category.ToLower()) || category.Count() == 0) &&
        //    (color.Contains(p.PrimaryColorCode.ToLower()) || color.Contains(p.SecondaryColorCode.ToLower()) || color.Count() == 0) &&
        //    (demographic.Contains(p.Demographic.ToLower()) || demographic.Count() == 0) &&
        //    (material.Contains(p.Material.ToLower()) || material.Count() == 0) &&
        //    ((p.Price >= minPrice || minPrice.Equals(0)) && (p.Price <= maxPrice || maxPrice.Equals(0))) &&
        //    (type.Contains(p.Type.ToLower()) || type.Count() == 0)).Skip(count: (int)range).Take(returnPatients).CountAsync();
        //}

        // public async Task<IEnumerable<Patient>> GetPatientsAsync(Nullable<bool> active, List<string> brand, List<string> category,
        //                                                       List<string> color, List<string> demographic, List<string> material,
        //                                                      decimal minPrice, decimal maxPrice, List<string> type, int? range, int returnPatients)
        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _ctx.Patients.ToListAsync();
        }
        //return await _ctx.Patients.Where(p =>
        //(p.Active == active || active == null) &&
        //(brand.Contains(p.Brand.ToLower()) || brand.Count() == 0) &&
        //(category.Contains(p.Category.ToLower()) || category.Count() == 0) &&
        //(color.Contains(p.PrimaryColorCode.ToLower()) || color.Contains(p.SecondaryColorCode.ToLower()) || color.Count() == 0) &&
        //(demographic.Contains(p.Demographic.ToLower()) || demographic.Count() == 0) &&
        //(material.Contains(p.Material.ToLower()) || material.Count() == 0) &&
        //((p.Price >= minPrice || minPrice.Equals(0)) && (p.Price <= maxPrice || maxPrice.Equals(0))) &&
        //(type.Contains(p.Type.ToLower()) || type.Count() == 0)).Skip(count: (int)range).Take(returnPatients).OrderBy((i) => i.Id).ToListAsync();
        public async Task<Patient> CreatePatientAsync(Patient product)
        {
            await _ctx.Patients.AddAsync(product);
            await _ctx.SaveChangesAsync();

            return product;
        }
        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            _ctx.Patients.Update(patient);
            await _ctx.SaveChangesAsync();

            return patient;
        }
        public async Task<Patient> DeletePatientByIdAsync(Patient product)
        {

            _ctx.Patients.Attach(product);
            _ctx.Patients.Remove(product);
            await _ctx.SaveChangesAsync();

            return product;

        }



        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _ctx.Patients.OrderBy((i) => i.Id).ToListAsync();
        }
    }
}




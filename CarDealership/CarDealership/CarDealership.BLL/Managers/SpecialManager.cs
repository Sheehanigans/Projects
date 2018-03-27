using CarDealership.Models.Interfaces;
using CarDealership.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.BLL.Managers
{
    public class SpecialManager
    {
        private ISpecialRepository Repo { get; set; }

        public SpecialManager(ISpecialRepository specialRepository)
        {
            Repo = specialRepository;
        }

        public SpecialGetAllResponse GetAllSpecials()
        {
            var response = new SpecialGetAllResponse();

            response.Specials = Repo.GetSpecials();

            if (!response.Specials.Any())
            {
                response.Success = false;
                response.Message = "Could not load any vehicles";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }
    }
}

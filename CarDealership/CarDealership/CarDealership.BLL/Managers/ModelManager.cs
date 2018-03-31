﻿using CarDealership.Models.Interfaces;
using CarDealership.Models.Responses;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.BLL.Managers
{
    public class ModelManager
    {
        private IModelRepository Repo { get; set; }

        public ModelManager(IModelRepository modelRepository)
        {
            Repo = modelRepository;
        }

        public TResponse<List<Model>> GetAllModels()
        {
            var response = new TResponse<List<Model>>();

            response.Payload = Repo.GetAllModels();

            if(response.Payload == null)
            {
                response.Message = "Unable to load models";
                response.Success = false;
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public TResponse<Model> SaveModel(Model model)
        {
            var response = new TResponse<Model>();

            response.Payload = Repo.Save(model);

            if(response.Payload == null)
            {
                response.Message = $"Unable to save model {model.ModelName}";
                response.Success = false;
            }
            else
            {
                response.Success = true;
            }

            return response;
        }
    }
}
// This file was auto-generated by ML.NET Model Builder. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ML;
using MLNETML.Model;

namespace MLModel
{
    public class ConsumeModel
    {
        // For more info on consuming ML.NET models, visit https://aka.ms/model-builder-consume
        // Method for consuming model in your app
        private static string ModelfilePath = $"{AppDomain.CurrentDomain.BaseDirectory}MLModel.zip";
        //public static string ModelfilePath= { get; set; }
        public static ModelOutput Predict(ModelInput input)
        {

            // Create new MLContext
            MLContext mlContext = new MLContext();

            // Load model & create prediction engine
            //string modelPath = @"C:\Users\Administrator\AppData\Local\Temp\MLVSTools\MLNETML\MLNETML.Model\MLModel.zip";
            ITransformer mlModel = mlContext.Model.Load(ModelfilePath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            // Use model to make prediction on input data
            ModelOutput result = predEngine.Predict(input);
            return result;
        }

        /// <summary>
        /// 获取验证数据
        /// </summary>
        /// <param name="dataFilePath"></param>
        /// <returns></returns>
        public static ModelInput CreateSingleDataSample(string dataFilePath)
        {
            // Create MLContext
            MLContext mlContext = new MLContext();

            // Load dataset
            IDataView dataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                            path: dataFilePath,
                                            hasHeader: true,
                                            separatorChar: ',',
                                            allowQuoting: true,
                                            allowSparse: false);

            // Use first line of dataset as model input
            // You can replace this with new test data (hardcoded or from end-user application)
            ModelInput sampleForPrediction = mlContext.Data.CreateEnumerable<ModelInput>(dataView, false)
                                                                        .First();
            return sampleForPrediction;
        }

    }
}

using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

namespace StabilityAi
{
    public class ImageGenerationApi
    {
        public delegate void StabilityAiResponseEventHandler(string message);
        public static event StabilityAiResponseEventHandler? OnStabilityAiResponseReceived;

        private static readonly string apiKey = "YOUR_KEY_HERE";
        private static readonly string apiEndPoint = "https://api.stability.ai/v1/generation/stable-diffusion-v1-6/text-to-image";
        private static readonly string contentType = "application/json";
        private static readonly string authorizationPrefix = "Bearer ";
        private static readonly string acceptImageType = "image/png";
        public static IEnumerator PostStabilityAIRequest(StabilityAiRequestParameters requestParameters)
        {
            string outputFilePath = Application.persistentDataPath + "/images/" + requestParameters.outputFileName;
            string requestBodyJsonStr = "{\"text_prompts\": [ {\"text\": \"" + requestParameters.promptText + "\"} ]," +
                                        "\"cfg_scale\": " + requestParameters.cfgScale.ToString() + "," +
                                        "\"height\": " + requestParameters.dimensions.y.ToString() + "," +
                                        "\"width\": " + requestParameters.dimensions.x.ToString() + "," +
                                        "\"samples\": " + requestParameters.samples.ToString() + "," +
                                        "\"steps\": " + requestParameters.steps.ToString() + " }";

            UnityWebRequest request = new UnityWebRequest(apiEndPoint, "POST");

            request.SetRequestHeader("Content-Type", contentType);
            request.SetRequestHeader("Accept", acceptImageType);
            request.SetRequestHeader("Authorization", authorizationPrefix + apiKey);

            byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(requestBodyJsonStr);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerFile(outputFilePath);

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                OnStabilityAiResponseReceived?.Invoke(outputFilePath);
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace asr_vietspeech
{
    public class SpeechText
    {
        private Configuration configuration;
        public static string ASR_URL = "http://asr.vietspeech.com:7070/v1/speech";
        private static readonly string FIELD_NAME = "voice";
        private static readonly string FIELD_ENCODING = "encoding";
        private static readonly string FIELD_TIMEOUT = "timeout";
        private static readonly string FIELD_SAMPLE_RATE = "sampleRate";
        private static readonly string FIELD_MAX_SIZE = "maxSize";
        private static readonly string AUTHORIZATION = "Authorization";
        // it can be Basic or another authorization way
        private static readonly string AUTHORIZE_PREFIX = "Bearer ";

        public SpeechText(Configuration configuration)
        {
            this.configuration = configuration;
        }

        /**
         * Call ASR Service to convert audio file to text with model language VietNamese
         * Method temp just support mime type Wave in this time
         *
         * @param fileStream File audio need to convert. It should be a .wav file
         * @return content of audio file by text
         */
         public async Task<string> Call(FileStream file)
         {
            if (!file.CanRead) throw new InvalidDataException("Invalid file.");
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add(AUTHORIZATION, AUTHORIZE_PREFIX + configuration.getToken());
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new StreamContent(file), FIELD_NAME);
            form.Add(new StringContent(configuration.getEncoding().ToString()), FIELD_ENCODING);
            form.Add(new StringContent(configuration.getTimeout().ToString()), FIELD_TIMEOUT);
            form.Add(new StringContent(configuration.getMaxSize().ToString()), FIELD_MAX_SIZE);
            form.Add(new StringContent(configuration.getSampleRateHertz().ToString()), FIELD_SAMPLE_RATE);
            HttpResponseMessage response = await httpClient.PostAsync(ASR_URL, form);
            httpClient.Dispose();
            string json = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine("ASR Reseponse: " + json);
            if (response.IsSuccessStatusCode)
            {

                SuccessResponse successResponse = JsonConvert.DeserializeObject<SuccessResponse>(json);
                if (successResponse != null)
                {
                    return successResponse.getText();
                }
                else
                {
                    Console.WriteLine("Something went wrong when call ASR.");
                    return null;
                }
            }
            else
            {
                if (response.StatusCode.Equals(HttpStatusCode.Forbidden))
                {
                    Console.WriteLine("Invalid token.");
                }
                else
                {
                    Console.WriteLine("Something went wrong when call ASR.");
                }
                return null;
            }
        }
    }
}

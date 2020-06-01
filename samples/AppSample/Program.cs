using asr_vietspeech;
using System;
using System.IO;

namespace AppSample
{
    class Program
    {
        static void Main(string[] args)
        {
            String token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6ImNjNDExOWMwLWExYzEtMTFlYS1iOTdjLTFiOTdlMzMzNTc2NCIsImlhdCI6MTU5MDc2NjYzNn0.K36Axz4FnuORA9jGr_6cs0CjV2vVAI9DZLxe5sjNb7A";
            Configuration config = new Configuration(token, AudioEncoding.AMR, 10000, 16000, 51200);
            SpeechText speech = new SpeechText(config);
            FileStream file = File.Create("./processing.wav");
            try
            {
                string result = speech.Call(file).Result;
                Console.WriteLine(result);
            } catch(AggregateException ex)
            {
                Console.WriteLine("Something went wrong" + ex.Message);
            }
        }
    }
}

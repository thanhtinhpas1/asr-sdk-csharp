using System;
using System.Collections.Generic;
using System.Text;

namespace asr_vietspeech
{
    public class SuccessResponse
    {
        private int returncode;
        private string returnmessage;
        private string text;

        public int getReturncode()
        {
            return returncode;
        }

        public void setReturncode(int returncode)
        {
            this.returncode = returncode;
        }

        public string getReturnmessage()
        {
            return returnmessage;
        }

        public void setReturnmessage(string returnmessage)
        {
            this.returnmessage = returnmessage;
        }

        public string getText()
        {
            return text;
        }

        public void setText(string text)
        {
            this.text = text;
        }
    }
}

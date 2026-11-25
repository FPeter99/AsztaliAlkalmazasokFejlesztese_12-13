namespace AktivaloKod_Lib
{
    public class ActivatetionCodeValidator
    {

        // AAAA-BBBB-CCCC a forma, különben: rossz helyen lévő kötőjelek
        // legalább 1 G és C és pont 1 J karakter és legalább  1 számegy
        // csak angol abc és szám
        // kis- és nagybetűs alakban is megfelel
        // kötőjelek nem kellenek, de ha van akkor 4-4-4 kell
        public bool CheckCodeValidity(string pass) 
        {
            if(AAAA_BBBB_CCCC_foma_vagy_AAAABBBBCCCC(pass) &&
               Tartalmaz_legalabb_egy_G_egy_C_es_egy_szamot_es_pont_egy_J____Csak_angol_abc_vagy_szam(pass) 
            ) 
            {
                return true;
            }
            return false;
        }

        private bool AAAA_BBBB_CCCC_foma_vagy_AAAABBBBCCCC(string pass) 
        {
            if (pass.Length == 12)
            {
                if (pass.Contains('-'))
                {
                    return false;
                }
                return true;
            }
            else if (pass.Length == 14) 
            {
                if (pass[4] == '-' && pass[9] == '-') { return true; }
            }

            return false;
        }

        private bool Tartalmaz_legalabb_egy_G_egy_C_es_egy_szamot_es_pont_egy_J____Csak_angol_abc_vagy_szam(string pass) 
        {
            pass = pass.ToLower();
            int intcount = 0;
            int JCount = 0;

            
            foreach (char c in pass) 
            {
                if (c == '-')
                {
                    // kötőjelet átugorjuk (már ellenőriztük a formátumban)
                    continue;
                }
                else if (char.IsDigit(c))
                {
                    intcount++;
                }
                else if (c == 'j')
                {
                    JCount++;
                    if (JCount > 1) { return false; }
                }
                else if (!char.IsAsciiLetterOrDigit(c)) 
                {
                    return false;
                }
            }



            if (pass.Contains('g') && pass.Contains('c') && intcount > 0 && JCount == 1) { return true; }
            return false;
        }
    
    
    
    }
}

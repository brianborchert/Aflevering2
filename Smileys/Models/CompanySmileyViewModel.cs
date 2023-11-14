namespace Smileys.Models
{
    public class CompanySmileyViewModel
    {
        private static List<string> paths = new List<string>()
        {
            "/images/smiley1.png",
            "/images/smiley2.png",
            "/images/smiley3.png",
            "/images/smiley4.png",
        };

        public List<Company>? Companies { get; set; }
        public Dictionary<int, List<string>>? CompanyIDsAndSmileyPaths { get; set; }

        public CompanySmileyViewModel(List<Company>? companies)
        {
            Companies = companies;
            CompanyIDsAndSmileyPaths = new Dictionary<int, List<string>>();

            Companies!.ForEach(company =>
            {
                int smiley1 = Int32.Parse(company.Smileys[0].ToString());   // the first character in the Company's Smileys string as an int
                int smiley2 = Int32.Parse(company.Smileys[1].ToString());   // the second character in the Company's Smileys string as an int
                int smiley3 = Int32.Parse(company.Smileys[2].ToString());
                int smiley4 = Int32.Parse(company.Smileys[3].ToString());

                List<string> companySmileyPaths = new List<string>();
                companySmileyPaths.Add(paths[smiley1 - 1]);  // the number 0 in [] here takes the first path in paths
                companySmileyPaths.Add(paths[smiley2 - 1]);
                companySmileyPaths.Add(paths[smiley3 - 1]);
                companySmileyPaths.Add(paths[smiley4 - 1]);

                CompanyIDsAndSmileyPaths!.Add(company.Id, companySmileyPaths);
            });
        }

        //public void PopulateCompanyIDsAndSmileyPaths()
        //{
        //    Companies!.ForEach(company =>
        //    {
        //            List<string> companySmileyPaths = new List<string>();
        //            companySmileyPaths.Add(paths[0]);
        //            companySmileyPaths.Add(paths[1]);
        //            companySmileyPaths.Add(paths[2]);
        //            companySmileyPaths.Add(paths[3]);
        //            CompanyIDsAndSmileyPaths!.Add(company.Id, companySmileyPaths);
        //    });
        //}
    }
}
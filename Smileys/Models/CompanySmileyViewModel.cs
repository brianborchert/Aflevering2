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
            CompanyIDsAndSmileyPaths = new Dictionary<int, List<string>>(); // A dictionary with a list of smiley paths for each company id

            Companies!.ForEach(company =>
            {
                List<string> companySmileyPaths = new List<string>();

                // The first 4 chars in the company's Smileys string are turned into ints, and then the corresponding smiley paths are added to a list
                for (int i = 0; i < 4; i++)
                {
                    bool pathAdded = false;
                    if (company.Smileys.Length > i)
                    {
                        int numberInCompanySmileys;
                        bool success = int.TryParse(company.Smileys[i].ToString(), out numberInCompanySmileys);  // The char at index i is parsed to an int
                        if (success && 0 < numberInCompanySmileys && numberInCompanySmileys < 5)  // Only ints 1, 2, 3 and 4 are accepted
                        {
                            companySmileyPaths.Add(paths[numberInCompanySmileys - 1]);  // The path at index corresponding to char's int value is added to list
                            pathAdded = true;
                        }
                    }
                    if (!pathAdded)
                    {
                        companySmileyPaths.Add("");
                        // If for example there are only 3 chars in company's Smiley string, then an empty path is added as the list's fourth entry
                        // If for example one of the chars in company's Smiley string is not '1', '2', '3' or '4', then an empty path is added
                    }
                }
                // The list now necessarily has 4 entries

                CompanyIDsAndSmileyPaths!.Add(company.Id, companySmileyPaths);
            });
        }
    }
}
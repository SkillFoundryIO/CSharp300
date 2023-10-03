namespace LINQPracticeMinis
{
    public class LINQPractice
    {
        private List<Luchador> _luchadores;

        public LINQPractice(List<Luchador> luchadores)
        {
            _luchadores = luchadores;
        }
        
        // Find all luchadores that haven't won a championship.
        public List<Luchador> GetLuchadoresWithoutChampionships()
        {
            return _luchadores.Where(l => l.Championships == 0).ToList();
        }

        // Find all luchadores from Mexico, order them by their alias.
        public List<Luchador> GetMexicanLuchadores()
        {
            return _luchadores.Where(l => l.Country == "Mexico").OrderBy(l => l.Alias).ToList();
        }

        // Find the luchador with the most wins.
        public Luchador GetLuchadorWithMostWins()
        {
            var result = (from l in _luchadores
                          orderby l.Wins descending
                          select l).First();

            return result;
        }

        // Find the average weight of all luchadores.
        public double GetAverageWeight()
        {
            return _luchadores.Average(l => l.WeightKg);
        }

        // Find the total number of wins by luchadores from the USA.
        public int GetTotalWinsByUSALuchadores()
        {
            return _luchadores.Where(l => l.Country == "USA")
                .Sum(l => l.Wins);
        }

        // Find the youngest luchador.
        public Luchador GetYoungestLuchador()
        {
            return _luchadores.OrderByDescending(l => l.DoB).First();
        }

        // Find all luchadores with a height above 180 cm who have won a championship.
        public List<Luchador> GetTallChampionLuchadores()
        {
            var result = from l in _luchadores
                         where l.HeightCm > 180 && l.Championships > 0
                         select l;

            return result.ToList();
        }

        // Find the luchadors who have more than the average number of draws.
        public List<Luchador> GetLuchadorsMoreAverageDraws()
        {
            var averageDraws = _luchadores.Average(l => l.Draws);

            return _luchadores.Where(l => l.Draws > averageDraws).ToList();
        }

        // Find the total number of championships won by Spanish luchadores.
        public int GetTotalChampionshipsBySpanishLuchadores()
        {
            return _luchadores.Where(l => l.Country == "Spain").Sum(l => l.Championships);
        }

        // Find the oldest luchador from Mexico.
        public Luchador GetOldestMexicanLuchador()
        {
            return _luchadores.Where(l => l.Country == "Mexico").OrderBy(l => l.DoB).First();
        }

        // Find all luchadores with more than 20 wins and less than 5 losses.
        public List<Luchador> GetSuccessfulLuchadores()
        {
            return _luchadores.Where(l => l.Wins > 20 && l.Losses < 5).ToList();
        }

        // Find the alias of the luchador with the lowest win to loss ratio.
        public string GetLuchadorWithLowestWinToLossRatio()
        {
            return _luchadores.Select(l => 
                new { 
                    l.Alias, 
                    WLRatio = l.Wins / (double)l.Losses 
                })
                .OrderByDescending(l => l.WLRatio)
                .First().Alias;
        }

        // Find the average number of wins by country.
        public Dictionary<string, double> GetAverageWinsByCountry()
        {
            var results = new Dictionary<string, double>();

            var byCountry = _luchadores.GroupBy(l => l.Country);

            foreach(var group in byCountry)
            {
                results.Add(group.Key, group.Average(g => g.Wins));
            }

            return results;
        }

        // Find all luchadores whose alias starts with the word "The".
        public List<Luchador> GetLuchadoresWithTheInAlias()
        {
            return _luchadores.Where(l => l.Alias.StartsWith("The")).ToList();
        }

        // Find the luchador with the most losses who has won at least one championship.
        public Luchador GetLuchadorWithMostLossesAndAChampionship()
        {
            return _luchadores.OrderByDescending(l => l.Losses).Where(l => l.Championships > 0).First();
        }

        // Find the total number of draws by luchadores who have not won any championships.
        public int GetTotalDrawsByLuchadoresWithoutChampionships()
        {
            return _luchadores.Where(l => l.Championships == 0).Sum(l => l.Draws);
        }

        // Find all luchadores who were born in the 1990s.
        public List<Luchador> GetLuchadoresBornInThe90s()
        {
            return _luchadores.Where(l => l.DoB.Year >= 1990 && l.DoB.Year < 2000).ToList();
        }

        // Find the luchador alias with the most matches (wins, losses, draws).
        public string GetLuchadorWithHighestAverageOfWinsLossesDraws(List<Luchador> luchadores)
        {
            return _luchadores.Select(l =>
                new
                {
                    l.Alias,
                    TotalMatches = l.Wins + l.Losses + l.Draws
                })
                .OrderByDescending(l => l.TotalMatches)
                .First().Alias;
        }

        // Find the country with the most luchadores.
        public string GetCountryWithMostLuchadores()
        {
            var countryCount = new Dictionary<string, int>();

            var grouping = _luchadores.GroupBy(l => l.Country);

            foreach(var group in grouping)
            {
                countryCount.Add(group.Key, group.Count());
            }

            return countryCount.OrderByDescending(d => d.Value).First().Key;
        }

        // Find the luchador with the longest alias name.
        public Luchador GetLuchadorWithLongestAlias()
        {
            return _luchadores.OrderByDescending(l => l.Alias.Length).First();
        }
    }
}

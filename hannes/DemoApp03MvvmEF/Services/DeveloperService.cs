using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class DeveloperService : IDeveloperService
    {
        public IList<Developer> GetDevelopers()
        {
            IList<Developer> ld = new List<Developer>();

            for ( int i = 0; i < 100; i++ )
            {
                Developer d = new Developer();

                d.Name = $"Developer {i}";
                d.EMail = $"developer{i}@demo.com";
                
                ld.Add(d);
            }

            return ld;
        }
    }
}

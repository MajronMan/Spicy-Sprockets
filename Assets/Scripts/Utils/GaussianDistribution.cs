using System;

namespace Assets.Scripts.Utils {
    /// <summary>
    /// Gaussian distribution using Box-Muller transformation
    /// Dunno how, but it works.
    /// </summary>
    public class GaussianDistribution {
        private double _mean;
        private double _standardDeviation;
        private Random _random = new Random();

        public GaussianDistribution(double mean, double standardDeviation) {
            _mean = mean;
            _standardDeviation = standardDeviation;
        }

        public double Next() {
            double z1 = _random.NextDouble();
            double z2 = _random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(z1)) * Math.Sin(2.0 * Math.PI * z2);
            return _mean + randStdNormal * _standardDeviation;
        }
    }
}
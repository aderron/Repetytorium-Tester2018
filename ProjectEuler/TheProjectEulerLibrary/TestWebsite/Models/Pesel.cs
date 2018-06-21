using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TestWebsite.Models
{
    [JsonConverter(typeof(PeselConverter))]
    public class Pesel : IEquatable<Pesel>
    {
        private readonly long value;

        private readonly List<int> digits;

        private readonly int[] weights = new[] {1, 3, 7, 9, 1, 3, 7, 9, 1, 3};

        public Pesel(string value)
        {
            if (value?.Length == 11)
            {
                var parsedDigits = value.ToCharArray().Select(c => c - '0').ToList();
                if (this.ValidatePesel(parsedDigits))
                {
                    this.digits = parsedDigits;
                    this.value = long.Parse(value);
                    return;
                }
            }

            throw new ApplicationException($"Invalid pesel {value}");
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public DateTime BirthDate
        {
            get
            {
                var year = 1900;
                var month = 0;
                if (digits[2] == 2)
                {
                    year += 100;
                    month = -20;
                }

                year += digits[0] * 10 + digits[1];
                month += digits[2] * 10 + digits[3];
                var day = digits[4] * 10 + digits[5];
                return new DateTime(year, month, 01);
            }
        }

        private bool ValidatePesel(IList<int> digits)
        {
            if (digits.Count != 11)
            {
                return false;
            }

            var sum = 0;
            for (var i = 0; i < 10; i++)
            {
                sum += digits[i] * this.weights[i];
            }

            var checksumDigit = 10 - (sum % 10);

            return digits[10] == checksumDigit;
        }

        public bool Equals(Pesel other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Pesel) obj);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }

    public class PeselConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is Pesel pesel)
            {
                writer.WriteRawValue($"\"{pesel}\"");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (string) reader.Value;
            return new Pesel(value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(Pesel));
        }
    }
}
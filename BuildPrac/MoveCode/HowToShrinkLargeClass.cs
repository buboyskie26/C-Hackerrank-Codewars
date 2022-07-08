using System;
using System.Collections.Generic;
using System.Text;

namespace BuildPrac.MoveCode
{
    class HowToShrinkLargeClass
    {
        class Person
        {
            internal string Name { get; set; }
            internal string TelephoneNumber { get; set; }
            internal string Email { get; set; }

            internal string Street { get; set; }
            internal int HouseNumber { get; set; }
            internal string City { get; set; }
            internal string PostalNumber { get; set; }
            internal string Country { get; set; }

            internal string GetFullAddress()
            {
                return $"{Street} {HouseNumber}, {PostalNumber} {City}, {Country}";
            }

            internal bool FreeDelivery()
            {
                return int.Parse(PostalNumber) < 40000;
            }

            //Other person methods here...
        }
    }

}

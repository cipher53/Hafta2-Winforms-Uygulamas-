using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme
{
    // 'Person' adında bir namespace (ad alanı) tanımlanıyor.
    // Bir namespace, kodunuzu organize etmek için kullanılır.
    // Bu durumda, 'deneme' adında bir namespace tanımlanıyor.
    class Person
    {
         // 'Person' sınıfı tanımlanıyor.
        // Bu sınıf, bir kişinin adını ve soyadını temsil edecek.

        // 'Name' adında bir string özellik (property) tanımlanıyor.
        // Bu özellik, bir kişinin adını tutacak.
        public string Name { get; set; }
        // 'LastName' adında bir string özellik (property) tanımlanıyor.
        // Bu özellik, bir kişinin soyadını tutacak.
        public string LastNAme { get; set; }
    }
}

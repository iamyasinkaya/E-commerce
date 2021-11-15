using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Shared.Utilities
{
    public static class Messages
    {
        public static class General
        {
            public static string ValidationError()
            {
                return $"Bir veya daha fazla validasyon hatası ile karşılaşıldı.";
            }
        }
        public static class Category
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir kategori bulunamadı.";
                return "Böyle bir kategori bulunamadı.";
            }
            public static string NotFoundById(string categoryId)
            {
                return $"{categoryId} Kategori koduna ait kategori bulunamadı";
            }

            public static string Add(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla eklenmiştir.";
            }

            public static string Update(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla silinmiştir.";
            }
            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori arşivden geri getirilmiştir.";
            }
        }
        public static class Product
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir ürün bulunamadı.";
                return "Böyle bir ürün bulunamadı.";
            }
            public static string NotFoundById(string productId)
            {
                return $"{productId} Ürün koduna ait ürün bulunamadı";
            }

            public static string Add(string productName)
            {
                return $"{productName} adlı ürün başarıyla eklenmiştir.";
            }

            public static string Update(string productName)
            {
                return $"{productName} adlı ürün başarıyla güncellenmiştir.";
            }
            public static string Delete(string productName)
            {
                return $"{productName} adlı ürün başarıyla silinmiştir.";
            }
            public static string HardDelete(string productName)
            {
                return $"{productName} adlı ürün başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string productName)
            {
                return $"{productName} adlı ürün arşivden geri getirilmiştir.";
            }
        }
        public static class Discount
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir indirim bulunamadı.";
                return "Böyle bir ürün bulunamadı.";
            }
            public static string NotFoundById(int discountId)
            {
                return $"{discountId} İndirim koduna ait indirim bulunamadı";
            }

            public static string Add(string discountCode)
            {
                return $"{discountCode} adlı indirim kodu başarıyla eklenmiştir.";
            }

            public static string Update(string discountCode)
            {
                return $"{discountCode} adlı indirim kodu başarıyla güncellenmiştir.";
            }
            public static string Delete(string discountCode)
            {
                return $"{discountCode} adlı indirim kodu başarıyla silinmiştir.";
            }
            public static string HardDelete(string discountCode)
            {
                return $"{discountCode} adlı indirim kodu başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string discountCode)
            {
                return $"{discountCode} adlı indirim kodu arşivden geri getirilmiştir.";
            }
        }

        public static class Order
        {
            public static string Create(int orderId)
            {
                return $"{orderId} numaralı siparişiniz başarıyla oluşturuldu.";
            }
        }
    }


}

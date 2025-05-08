using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagerConsole.Models;
using ProductManagerConsole.Factory;
using ProductManagerConsole.Repository;

namespace ProductManagerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ProductRepository productRepo = new ProductRepository();

            List<Category> categories = new List<Category>
            {
                new Category { Id = 1, Name = "Điện tử" },
                new Category { Id = 2, Name = "Thực phẩm" }
            };

            List<Supplier> suppliers = new List<Supplier>
            {
                new Supplier { Id = 1, Name = "Công ty A" },
                new Supplier { Id = 2, Name = "Công ty B" }
            };

            while (true)
            {
                Console.WriteLine("\n===== QUẢN LÝ SẢN PHẨM =====");
                Console.WriteLine("1. Thêm sản phẩm");
                Console.WriteLine("2. Hiển thị tất cả");
                Console.WriteLine("3. Xoá sản phẩm");
                Console.WriteLine("4. Tìm kiếm sản phẩm");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Tên sản phẩm: ");
                    string name = Console.ReadLine();

                    Console.WriteLine("Chọn danh mục:");
                    for (int i = 0; i < categories.Count; i++)
                    {
                        Console.WriteLine(categories[i].Id + ". " + categories[i].Name);
                    }
                    int catId = int.Parse(Console.ReadLine());
                    Category selectedCat = categories.Find(c => c.Id == catId);

                    Console.WriteLine("Chọn nhà cung cấp:");
                    for (int i = 0; i < suppliers.Count; i++)
                    {
                        Console.WriteLine(suppliers[i].Id + ". " + suppliers[i].Name);
                    }
                    int supId = int.Parse(Console.ReadLine());
                    Supplier selectedSup = suppliers.Find(s => s.Id == supId);

                    Product product = ProductFactory.CreateProduct(name, selectedCat, selectedSup);
                    productRepo.Add(product);
                    Console.WriteLine("✔️ Sản phẩm đã được thêm!");
                }
                else if (choice == "2")
                {
                    IEnumerable<Product> all = productRepo.GetAll();
                    foreach (Product p in all)
                    {
                        Console.WriteLine("#" + p.Id + " - " + p.Name + " | " + p.Category.Name + " | " + p.Supplier.Name);
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("Nhập ID sản phẩm cần xoá: ");
                    int id = int.Parse(Console.ReadLine());
                    bool deleted = productRepo.Delete(id);
                    Console.WriteLine(deleted ? "✔️ Đã xoá!" : "❌ Không tìm thấy!");
                }
                else if (choice == "4")
                {
                    Console.Write("Từ khoá tìm kiếm: ");
                    string keyword = Console.ReadLine();
                    IEnumerable<Product> results = productRepo.SearchByName(keyword);
                    foreach (Product p in results)
                    {
                        Console.WriteLine("#" + p.Id + " - " + p.Name);
                    }
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Nhấn phím bất kỳ để thoát...");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("❗ Lựa chọn không hợp lệ.");
                }
            }
        }
    }
}


# Article Project
Makale Api
# Proje Kurulumu
- Docker kullanarak projeyi başlatmak için docker-compose dosyasının olduğu dizinde aşağıda ki komutu çalıştırın.
```
git clone https://github.com/mykaratas/article-project.git
```
```
cd article-project
```

mssql'i docker imajı üzerinden çalıştırıyorum. Bilgisayarınızdaki mssqli'de kullanabilirsiniz. connection string düzenlenmelidir
NOT:article.root katmanı üzerinde '~/article.root/CompositionRoot.cs' UseSqlServer metodunun ilk parametresinden değiştirebilirsiniz.

``` 
docker-compose up -d
```
Uyarı: mevcutta localhost üzerinden 1433 portunu kullanan bir host varsa yukarıda değiştirirseniz çakışma olmayacaktır.

## Migrations
**Database ortamı kurulduktan sonra DbContextlermize tanımlanan article.data katmanındaki modeller entity prop'lar ve annotationlara göre bir tablolar ve şema oluşacaktır. **
Bunun için yapmamız gereken 3 adım var. 

```
1-) cd article-api   // bu dizinden Gidiyoruz çünkü EFCore.Desing kütüphanesi burada yüklü migrate işlemlerini bu kütüphane yapmakta.
```

```
2-) dotnet ef migrations add initialize
```

```
3-) dotnet ef database update
```

#START
(article.api dizininde)
```
dotnet build
```
```
dotnet watch run
```

POSTMAN COLLECTİON: https://www.getpostman.com/collections/599fa55463618bd68860


## Design Patterns
#### Repository Pattern
#### Dependency Injection Decorator pattern
#### Unit Of Work
#### Strategy Design Patterns
#### Dependency Injection

## Kullanılan Teknolojiler
#### Entity Framework
#### Linq
#### MSSQL
#### Dotnet Core(3.1)
#### Docker

## ilerde Tamamlamak İstediğim İşler
#### Unit testler test ortamının kurulması ve mocha vb node js kütüphaneleri ile gerçek testlerin yapılması.
#### Swagger Stoplight vb dökümantasyon ortamının kurgulanması mimari kurgulandıktan sonra yapılması daha makul.
#### Logların Microsoft.Extensions.Logging vb kütüphane ile programlanması ve Sentry(https://docs.sentry.io/platforms/dotnet/guides/aspnetcore/) ile canlıdaki hataların raporlanması.
#### Authorization ile kurguların uluşturulup programlanması login register singin vb için token yapısı ve servislerin yazılması.
#### S3 bucket vb ortamlarının programlanması. Amazon Web Service vb kullanılabilir. Burada video hizmeti sunacak ise stream için serverles kullnılabilir.




NOT: Öncelikle bu değerlendirme projesi için çok teşekkür ederim kabul edilsin veya edilmesin güzel şeyler kattı bana verimli oldu benim için. .net tecrübe eksikliğim var farkındayım kendimi geliştirmek için elimden geleni yapmaya hazırım hızlıca adapte olup güzel işler çıkarabilirim. Çalıkan bir kişiliğim var.



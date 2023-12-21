# Book Store

Bu proje, .NET Core Web API kullanarak öğrenme amaçlı bir proje olup, aşağıdaki temel özelliklere sahiptir:

## Kullanılan Teknolojiler

- .NET Core
- Entity Framework Core
- AutoMapper
- Fluent Validation

## Özellikler

1. **Middleware Kullanımı**: Proje, özelleştirilmiş middleware'ler kullanarak Alınan hatalar özelleştirildi.

2. **Automapper Entegrasyonu**: AutoMapper kütüphanesi, model dönüşümlerini kolaylaştırmak için kullanılmaktadır. `MappingProfile` sınıfında tanımlıdır.

3. **ORM ve Entity Framework Core**: Veritabanı işlemleri için Entity Framework Core kullanılmıştır. `DbContext`  projede bulunmaktadır.

4. **Fluent Validation**: Proje, giriş modeli doğrulamalarını gerçekleştirmek için Fluent Validation kütüphanesini içermektedir.

5. **Dependency Injection**: Servisler ve bağımlılıklar, .NET Core'un yerleşik dependency injection mekanizması kullanılarak yönetilmektedir.

6. **Kimlik Doğrulama ve Yetkilendirme**: Proje, temel kimlik doğrulama ve yetkilendirme protokollerini içermektedir.


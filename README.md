# PetWorld

**PetWorld** to sklep internetowy oferujący produkty dla zwierząt domowych.  
Klienci mogą zadawać pytania o produkty poprzez chat, a system AI (Writer + Critic) pomaga im znaleźć odpowiednie produkty i udziela porad.

Aplikacja jest zbudowana w oparciu o **Blazor Server**, **Clean Architecture / Onion Architecture** oraz wykorzystuje **Microsoft Agent Framework** do integracji z AI.

---

## Funkcjonalności

- **Strona 1 – Chat z klientem**  
  - Pole tekstowe do wpisania pytania
  - Przycisk "Wyślij"
  - Wyświetlenie odpowiedzi AI i liczby iteracji Writer-Critic (maks. 3)

- **Strona 2 – Historia czatu**  
  - Tabela z listą pytań i odpowiedzi
  - Kolumny: Data, Pytanie, Odpowiedź, Liczba iteracji

- **System AI – Writer-Critic**  
  - **Writer Agent**: generuje odpowiedź, rekomenduje produkty
  - **Critic Agent**: ocenia odpowiedź, zwraca `approved: true/false` + feedback
  - Maksymalnie 3 iteracje

- **Baza danych:** MySQL z tabelami `Products` i `ChatHistory`

---

## Technologie

- **Back-end:** .NET 7, C#, ASP.NET Core, Clean Architecture
- **Front-end:** Blazor Server
- **Baza danych:** MySQL
- **AI:** Microsoft Agent Framework, OpenAI GPT-3.5
- **Konteneryzacja:** Docker Compose

---

## Struktura projektu

```
PetWorld.sln
│
├─ Solution Items
│ └─ docker-compose.yml
│
├─ PetWorld.Application
│ ├─ Agents
│ │ ├─ CriticResult.cs
│ │ ├─ ICriticAgent.cs
│ │ ├─ IWriterAgent.cs
│ │ └─ WriterResult.cs
│ ├─ DTO
│ │ └─ ChatResponse.cs
│ ├─ Orchestration
│ │ └─ WriterCriticOrchestrator.cs
│ └─ Services
│ ├─ ChatHistoryService.cs
│ ├─ ChatService.cs
│ ├─ IChatHistoryService.cs
│ ├─ IChatService.cs
│ ├─ IProductService.cs
│ └─ ProductService.cs
│
├─ PetWorld.Domain
│ ├─ Entities
│ │ ├─ ChatHistoryEntry.cs
│ │ └─ Product.cs
│ └─ Repositories
│ ├─ IChatHistoryRepository.cs
│ └─ IProductRepository.cs
│
├─ PetWorld.Infrastructure
│ ├─ Agents
│ │ ├─ CriticAgent.cs
│ │ └─ WriterAgent.cs
│ ├─ Data
│ │ ├─ DbInitializer.cs
│ │ ├─ PetWorldDbContext.cs
│ │ └─ PetWorldDbContextFactory.cs
│ ├─ Migrations
│ │ └─ [EF generated migration files]
│ └─ Repositories
│ ├─ ChatHistoryRepository.cs
│ └─ ProductRepository.cs
│
└─ PetWorld.Web
├─ Pages
│ ├─ _Host.cshtml
│ ├─ Chat.razor
│ ├─ Chat.razor.cs (ChatBase)
│ ├─ ChatHistory.razor
│ └─ ChatHistory.razor.cs (ChatHistoryBase)
├─ Shared
│ └─ MainLayout.razor
├─ _Imports.razor
├─ App.razor
├─ Program.cs
├─ appsettings.json
├─ Dockerfile
└─ wwwroot
```
---

## Instalacja i uruchomienie

1. Skopiuj repozytorium:
```bash
git clone https://github.com/Saurus77/PetWorld.git
cd PetWorld
```
2. Ustaw systemową zmienną środowiskową z kluczem OpenAI:
```bash
export OPENAI_API_KEY=<TWÓJ_API_KEY>
# Windows PowerShell: $env:OPENAI_API_KEY="<TWÓJ_API_KEY>"
# Lub ręcznie w zaawansowanych ustawieniach systemu
```
3. Uruchom aplikację za pomocą dockera:
```bash
docker compose up --build
```
4. Dostęp do aplikacji po uruchomieniu:
```bash
http://localhost:5000
# Baza danych MySQL zostanie automatycznie zainicjalizowana z przykładowymi produktami.
# Aplikacja korzysta z workflow Writer-Critic, który generuje odpowiedzi AI i rekomendacje produktów.
```
---
## Zmienne konfiguracyjne
1. ```OPEN_API_KEY``` - klucz API do OpenAI/Azure
2. ```DefaultConnection``` - connection string do MySQL (```appsettings.json```)

---

## Działanie aplikacji
```
1. Użytkownik wpisuje pytanie w polu czatu.
2. Writer Agent generuje odpowiedź i opcjonalnie rekomenduje produkty.
3. Critic Agent ocenia odpowiedź i zwraca approved lub feedback.
4. Maksymalnie 3 iteracje – jeśli odpowiedź zostanie zatwierdzona wcześniej, proces się kończy.
5. Wynik zapisywany jest w tabeli historii czatu (ChatHistory).
6. Strona Historia wyświetla wszystkie pytania, odpowiedzi i liczbę iteracji.
```

---

## Autor
Mikołaj Żółciński

---
## Licencje
```
1. MIT
```

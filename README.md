# FileConverter

A versatile file format converter library and CLI tool supporting multiple formats including JSON, YAML, CSV, and XML.  
Designed with a plugin architecture for easy extensibility and reliable conversion between common data serialization formats.

---

## ✨ Features

- ✅ Convert **JSON ↔ YAML**
- ✅ Convert **JSON ↔ CSV**
- ✅ Convert **JSON ↔ XML**
- ✅ Clean and modular architecture using plugins
- ✅ Fully tested with xUnit

---

## 📦Supported Conversions

| From  | To    |
|-------|-------|
| JSON  | YAML  |
| YAML  | JSON  |
| CSV   | JSON  |
| JSON  | CSV   |
| XML   | JSON  |
| JSON  | XML   |

---

## 🚀Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later installed
- IDE or text editor of your choice (Visual Studio, VS Code, etc.)

### Build the project

Run the following in your terminal at the project root:

```bash
dotnet build
````
Run the CLI tool
Basic usage example converting JSON to YAML:
```bash
dotnet run --project FileConverter.CLI -- --input input.json --output output.yaml --from json --to yaml
```
Change --from and --to to any supported formats (json, yaml, csv, xml) and update file paths accordingly.

## 🧱 Project Structure
```pgsql
FileConverter.CLI/         → Main CLI interface
FileConverter.Core/        → Interfaces and core abstractions
FileConverter.Plugins/     → Format converters (JSON, XML, YAML, CSV)
FileConverter.Tests/       → xUnit test projects
```

## ➕Example Conversions 
- `JSON to YAML`
Input JSON: 
```json
[
  { "name": "Laura", "age": 30 },
  { "name": "Max", "age": 25 }
]
```
Output YAML: 
```yaml
- name: Laura
  age: 30
- name: Max
  age: 25
```

- `CSV to JSON`
Input CSV:
```csv
name,age
Laura,30
Max,25
```
Output JSON: 
```json
[
  { "name": "Laura", "age": 30 },
  { "name": "Max", "age": 25 }
]
```

- `XML to JSON`
  Input XML:
```xml
<people>
  <person>
    <name>Laura</name>
    <age>30</age>
  </person>
  <person>
    <name>Max</name>
    <age>25</age>
  </person>
</people>
```
  Output JSON:
  ```json
{
  "people": {
    "person": [
      { "name": "Laura", "age": 30 },
      { "name": "Max", "age": 25 }
    ]
  }
}
````

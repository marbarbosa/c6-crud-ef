# Curso 6 - Fundamentos do ASP.NET 6

* Criar um projeto novo tipo web.
* Como usar os verbos de requisições web: GET, POST, PUT, DELETE
* Como testar com a ferramenta POSTMAN.

## 🚀 Introdução e Minimal API

Fazer uma API que retorne uma requisição do tipo GET e POST.

### 📋 Pré-requisitos

De que coisas você precisa:

```
VSCode
Postman
```

## ⚙️ Executando os testes

Ao executar a aplicação, abrir o browser com o Localhost e IP criado pelo VSCode.

### 🔩 GET

Para o método GET, tem duas funcionalidades.

Sem parâmetro

```csharp
app.MapGet("/", Ola);
public static string Ola()
{
    return "Hello Word!";
}
```

Com parâmetro, "nome"

```csharp
app.MapGet("/{nome}", (string nome) =>
{
    return $"Olá {nome}, seja bem vindo";
});
```

### ⌨️ POST

Recebe, e retorna um JSON

```csharp
app.MapPost("/", (Usuario usuario) =>
{
    usuario.Id++;
    usuario.Nome = string.Concat(usuario.Nome, " Teste");
    return usuario;
});
```

## ✒️ Autores

* **Curso Balta.io** - [baltaio](https://balta.io)
* **Marcos Barbosa** - [linkedin](https://www.linkedin.com/in/marcos-castro-83094b184/)

## 🎁 Para pensar

```
"Se existe algo contra o qual o homem deva lutar decididamente, é todo pensamento que pretenda contrapor-se aos propósitos de bem que acalentam uma aspiração."
Raumsol - Coletanea da Revista Logosofia TOMO III
```

---

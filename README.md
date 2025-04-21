# Hospital Portal

A secure, simple, and production-ready **Hospital Management System (HMS)** built with **ASP.NET Core Razor Pages**, featuring:

- 🔐 **SAML 2.0 Single Sign-On (SSO)** integration via **Okta**
- 🐳 **Dockerized** deployment to **Render**
- 🌐 Fully **HTTPS-compliant** with secure cookie handling
- 📋 Admin interface for managing patients, doctors, and drug data
- ⚙️ Extensible architecture with clean backend/frontend separation

---
## Features

- **Responsive Design**: Built with TailwindCSS for a modern and responsive UI.
- **Login Page**: A clean and accessible login form.
- ✅ Secure SAML SSO login with Okta (SP-initiated & IdP-initiated)
- ✅ Razor Pages UI with clean admin views
- ✅ PostgreSQL integration (for admin, doctor, patient, drug data)
- ✅ HTTPS support in local and production environments
- ✅ Environment-based configuration (Dev vs Production)
- ✅ Render-ready deployment (container-based)

## Project Structure

- **Pages**: Contains Razor Pages for the application.
  - `Index.cshtml`: The home page with a login form.
  - `Shared/_Layout.cshtml`: The shared layout for consistent UI.
- **wwwroot**: Contains static files like CSS, JavaScript, and images.
  - `css/site.css`: Custom styles for the application.

## Technologies Used

- **.NET 9**: The latest version of .NET for building web applications.
- **C# 13.0**: The programming language used for server-side logic.
- **TailwindCSS**: A utility-first CSS framework for styling.

## How to Run

1. Clone the repository:
   `git clone https://wwww.github.com/chirix33/hospitalportalui`

2. Navigate to the project directory:
	`cd HospitalPortal`

3. Build and Run the project:
	`dotnet run`

4. Open your browser and navigate to `https://localhost:5000`.

## Customization

- **Accent Colors**: Modify `accent-blue` and `accent-white` in your TailwindCSS configuration.
- **SVG Backgrounds**: Add or replace SVG files in `wwwroot/lib/pictures/`.

## License

This project is licensed under the [MIT License](LICENSE).
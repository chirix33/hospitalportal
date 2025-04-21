# Hospital Portal

Hospital Portal is a Razor Pages web application designed for administrative tasks. This project is built using .NET 9 and TailwindCSS for styling.

## Features

- **Responsive Design**: Built with TailwindCSS for a modern and responsive UI.
- **Custom Accent Colors**: Includes `accent-blue` and `accent-white` for branding.
- **Login Page**: A clean and accessible login form.
- **SVG Backgrounds**: Supports custom SVG backgrounds for enhanced visuals.

## Project Structure

- **Pages**: Contains Razor Pages for the application.
  - `Index.cshtml`: The home page with a login form.
  - `Shared/_Layout.cshtml`: The shared layout for consistent UI.
- **wwwroot**: Contains static files like CSS, JavaScript, and images.
  - `css/site.css`: Custom styles for the application.
  - `lib/pictures/flower.svg`: Example SVG used as a background.

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

4. Open your browser and navigate to `http://localhost:5000`.

## Customization

- **Accent Colors**: Modify `accent-blue` and `accent-white` in your TailwindCSS configuration.
- **SVG Backgrounds**: Add or replace SVG files in `wwwroot/lib/pictures/`.

## License

This project is licensed under the [MIT License](LICENSE).
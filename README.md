# Taku Super Cool Widget Demo

A cross-platform .NET MAUI application showcasing various UI components and widgets. This app demonstrates modern mobile and desktop application development using .NET MAUI framework.

## Features

- 🎨 Modern UI with side navigation menu
- 💫 Custom splash screen with animations
- 👤 Profile management
- 🖼️ Image galleries and media handling
- 🎴 Card-based layouts
- 📊 Progress indicators
- 📑 Table views
- 🎯 Cross-platform support (iOS, Android, Windows, macOS)

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (17.8 or later) with the following workloads:
  - Mobile development with .NET
  - Universal Windows Platform development
  - .NET Desktop Development
- For iOS/macOS development:
  - Mac computer with macOS Catalina (10.15) or later
  - Xcode 13.0 or later
  - Visual Studio 2022 for Mac or Visual Studio 2022 on Windows with Mac build host

## Getting Started

1. Clone the repository
```bash
git clone [your-repo-url]
cd TakuMaui
```

2. Open the solution
- Double click `TakuMaui.sln` or
- Open Visual Studio 2022 and select `File > Open > Project/Solution`

3. Select your target platform
- Windows: Select `Windows Machine` in the run button dropdown
- Android: Select an Android Emulator or connected device
- iOS/macOS: Select a simulator or connected device (requires Mac build host)

4. Press F5 or click the Run button to build and run the application

## Project Structure

- `/Pages` - Contains all the page views
  - CardsPage - Card layout demonstrations
  - ImagesPage - Image gallery and media handling
  - ProfilePage - User profile management
  - ProgressBarsPage - Progress indicators and loading states
  - TablesPage - Table view implementations
  - SplashPage - Custom splash screen

- `/Resources` - Contains application resources
  - `/AppIcon` - Application icons
  - `/Images` - Image assets
  - `/Fonts` - Custom fonts
  - `/Styles` - XAML styles and themes

## Build and Deploy

### Android
```bash
dotnet build -f net8.0-android
dotnet publish -f net8.0-android
```

### iOS
```bash
dotnet build -f net8.0-ios
dotnet publish -f net8.0-ios
```

### Windows
```bash
dotnet build -f net8.0-windows10.0.19041.0
dotnet publish -f net8.0-windows10.0.19041.0
```

### macOS
```bash
dotnet build -f net8.0-maccatalyst
dotnet publish -f net8.0-maccatalyst
```

## Minimum Platform Requirements

- iOS: 11.0 or later
- Android: API 21 (Android 5.0) or later
- Windows: Windows 10 version 10.0.17763.0 or later
- macOS: 13.1 or later

## Technologies Used

- .NET MAUI
- C# 11
- XAML
- .NET 8.0

## Version

Current Version: 1.0

## License

[Your chosen license]

## Contributing

[Your contribution guidelines]

## Support

[Your support information]
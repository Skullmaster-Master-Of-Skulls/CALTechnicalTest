# Use the ASP.NET 4.8 base image on Windows Server Core
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.7.2-windowsservercore-ltsc2019

# Set the working directory inside the container
WORKDIR /inetpub/wwwroot

# Copy the application files to the container
COPY . .

# Expose port 80 for the application
EXPOSE 80

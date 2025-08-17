# Use Node.js image for build stage
FROM node:22.18.0 AS build

# Set working directory
WORKDIR /app

# Copy package files for dependency installation
COPY package*.json ./

# Install dependencies
RUN npm install --f

# Install Angular CLI globally
RUN npm install -g @angular/cli

# Copy application source code
COPY . .

# Build Angular app
RUN ng build

# Use Nginx for serving the built app
FROM nginx:latest

# Copy built frontend to Nginx html directory
COPY --from=build app/dist/frontend/browser /usr/share/nginx/html

# Copy custom Nginx configuration
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Expose port 80 for web traffic
EXPOSE 80
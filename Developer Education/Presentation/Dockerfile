# Docker container image for node web app
# https://nodejs.org/en/docs/guides/nodejs-docker-webapp/

# Build image from node version 10
FROM node:10

# Create app directory in the image
WORKDIR /usr/src/app

# Install app dependencies
# A wildcard is used to ensure both package.json AND package-lock.json are copied
# where available (npm@5+)
COPY package*.json ./

# RUN npm install
# If you are building your code for production
RUN npm ci --only=production

# Bundle app source
COPY . .

# EXPOSE port 8080 instruction to have it mapped by the docker daemon:
EXPOSE 8080

# Run application
CMD [ "node", "app.js" ]
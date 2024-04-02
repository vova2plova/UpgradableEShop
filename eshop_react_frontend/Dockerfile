FROM node:15.13-alpine
WORKDIR /frontend-app
COPY . .
RUN npm run build
CMD ["npm" , "start"]
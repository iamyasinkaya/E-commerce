# E-commerce Application with Microservice Architecture

# Description

As a member of the app, you can start shopping.If you're an admin in the app, you can create categories and open your products for sale.

![Build Status](https://img.shields.io/github/checks-status/iamyasinkaya/ECOM_PROJECT/main?style=for-the-badge)
![Build Status](https://img.shields.io/readthedocs/readme?style=for-the-badge)
![Build Status](https://img.shields.io/github/downloads/iamyasinkaya/ECOM_PROJECT/1.0.0/total?style=for-the-badge)
![Build Status](https://img.shields.io/github/directory-file-count/iamyasinkaya/ECOM_PROJECT?style=for-the-badge)
![Build Status](https://img.shields.io/apm/l/readme?style=for-the-badge)






# Technologies
- EntityFrameworkCore
- FluentValidation
- AutoMapper
- Swagger
- Docker
- MsSQL
- PostgreSQL
- MongoDB
- RabbitMq
- Redis
- IdentityServer
- MassTransit
- Ocelot
- JWT

## Installation

## Plugins

Ecommerce is currently extended with the following plugins.
Instructions on how to use them in your own application are linked below.

| Plugin | README |
| ------ | ------ |
| Portainer | The link will be added.|
| MongoDB | The link will be added. |
| PostgreSQL | The link will be added. |
| MsSQL | The link will be added. |
| Redis | The link will be added.|
| IdentityServer | The link will be added. |
| RabbitMQ | The link will be added. |

## Docker

Ecommerce is very easy to install and deploy in a Docker container.

By default, the Docker will expose port 8080, so change this within the
Dockerfile if necessary. When ready, simply use the Dockerfile to
build the image.

```sh
cd dillinger
docker build -t <youruser>/dillinger:${package.json.version} .
```

This will create the ecommerce image and pull in the necessary dependencies.
Be sure to swap out `${package.json.version}` with the actual
version of Ecommerce.

Once done, run the Docker image and map the port to whatever you wish on
your host. In this example, we simply map port 8000 of the host to
port 8080 of the Docker (or whatever port was exposed in the Dockerfile):

```sh
docker run -d -p 8000:8080 --restart=always --cap-add=SYS_ADMIN --name=ecommerce <youruser>/ecommerce:${package.json.version}
```

> Note: `--capt-add=SYS-ADMIN` is required for PDF rendering.

Verify the deployment by navigating to your server address in
your preferred browser.

```sh
127.0.0.1:8000
```







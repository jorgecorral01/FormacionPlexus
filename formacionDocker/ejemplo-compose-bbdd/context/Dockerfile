FROM composer as backend

WORKDIR /app

COPY composer.json composer.lock /app/
RUN composer install \
	--ignore-platform-reqs \
	--no-ansi \
	--no-autoloader \
	--no_dev \
	--no-interaction \
	--no-scripts
	
COPY . /app/
RUN composer dump-autoload --no-dev --optimize --classmap-authoritative


FROM php:7.2-apache

LABEL maintainer = "jcc"
LABEL application = "MyAPP"

RUN pecl install xdebug-2.6.0 \
	&& docker-php-ext-enable xdebug \
	&& docker-php-ext-install pdo pdo_mysql

ENV DISPLAY_ERRORS = "On"

WORKDIR /app

copy php.ini /usr/local/etc/php/
copy --from=backend /app /var/www/html/

#CMD ["/bin/bash"]
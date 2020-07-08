const gulp = require('gulp');
const shell = require('gulp-shell');
const { series } = require('gulp');


function startDatabase() {
    return gulp.src(__filename)
        .pipe(shell([`docker-compose up -d buybox-db`]));
}

function resetDatabase() {
    return gulp.src(__filename)
        .pipe(shell([`docker-compose exec -d buybox-db bash -c "mysql -u root </sql/init-db.sql"`]));
}

function logsDatabase() {
    return gulp.src(__filename)
        .pipe(shell([`docker-compose logs buybox-db`]));
}

function buildApi() {
    return gulp.src(__filename)
        .pipe(shell([`dotnet build`]));
}

function publishApi() {
    return gulp.src(__filename)
        .pipe(shell([`dotnet publish -o ./BuyBox.Api/dist/BuyBox.Api`]));
}

function startApi() {
    return gulp.src(__filename)
        .pipe(shell([ `docker-compose up -d buybox-api`]));
}

function logsApi() {
    return gulp.src(__filename)
        .pipe(shell([ `docker-compose logs buybox-api`]));
}

function buildWeb() {
    return gulp.src(__filename)
        .pipe(shell([`yarn`, `ng build`], { cwd: './BuyBox' }));
}

function startWeb() {
    return gulp.src(__filename)
        .pipe(shell([ `docker-compose up -d buybox-web`]));
}

function disposeContainers() {
    return gulp.src(__filename)
        .pipe(shell([`docker-compose down`]));
}

function clean() {
    return gulp.src(__filename)
        .pipe(shell('dotnet clean'));
}





exports.startDatabase = startDatabase;
exports.logsDatabase = logsDatabase;
exports.resetDatabase = resetDatabase;

exports.buildApi = buildApi;
exports.publishApi = publishApi;
exports.startApi = startApi;
exports.logsApi = logsApi;

exports.buildWeb = buildWeb;
exports.startWeb = startWeb;
exports.disposeContainers = disposeContainers;

exports.clean = clean;

exports.default = series(startDatabase, buildApi, publishApi, startApi, buildWeb, startWeb, resetDatabase);
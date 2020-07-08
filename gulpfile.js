const gulp = require('gulp');
const shell = require('gulp-shell');
const { series } = require('gulp');


function startDatabase() {
    return gulp.src(__filename)
        .pipe(shell([`docker-compose up -d db`]));
}

function resetDatabase() {
    return gulp.src(__filename)
        .pipe(shell([`docker-compose exec -d db bash -c "mysql -u root </sql/init-db.sql"`]));
}

function logsDatabase() {
    return gulp.src(__filename)
        .pipe(shell([`docker-compose logs db`]));
}

function buildApi() {
    return gulp.src(__filename)
        .pipe(shell([`dotnet publish -o ./BuyBox.Api/dist/BuyBox.Api`]));
}

function startApi() {
    return gulp.src(__filename)
        .pipe(shell([ `docker-compose up -d api`]));
}

function logsApi() {
    return gulp.src(__filename)
        .pipe(shell([ `docker-compose logs api`]));
}

function buildWeb() {
    return gulp.src(__filename)
        .pipe(shell([`yarn`, `ng build`], { cwd: './BuyBox' }));
}

function startWeb() {
    return gulp.src(__filename)
        .pipe(shell([ `docker-compose up -d web`]));
}

function disposeContainers() {
    return gulp.src(__filename)
        .pipe(shell([`docker-compose down`]));
}

function clean() {
    return gulp.src(__filename)
        .pipe(shell('dotnet clean'));
}


function build() {
    return gulp.src(__filename)
        .pipe(shell([`dotnet build`]));
}


exports.startDatabase = startDatabase;
exports.logsDatabase = logsDatabase;
exports.resetDatabase = resetDatabase;

exports.buildApi = buildApi;
exports.startApi = startApi;
exports.logsApi = logsApi;

exports.buildWeb = buildWeb;

exports.disposeContainers = disposeContainers;

exports.clean = clean;
exports.build = build;

exports.default = series(startDatabase, buildApi, startApi, buildWeb, startWeb, resetDatabase);
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

function test() {
    return gulp.src(__filename)
        .pipe(shell([`dotnet test`]));
}

function publish() {
    return gulp.src(__filename)
        .pipe(shell([`dotnet publish`]));
}

exports.startDatabase = startDatabase;
exports.resetDatabase = resetDatabase;
exports.logsDatabase = logsDatabase;
exports.disposeContainers = disposeContainers;


exports.clean = clean;
exports.build = build;
exports.test = test;
exports.publish = publish;

exports.default = series(clean, build, test, publish)
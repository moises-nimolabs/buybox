const gulp = require('gulp');
const shell = require('gulp-shell');

gulp.task('start-db', () => {
    return gulp.src(__filename)
        .pipe(shell([`docker-compose up -d db`]));
});

gulp.task('reset-db', () => {
    return gulp.src(__filename)
    .pipe(shell([`docker-compose exec -d db bash -c "mysql -u root </sql/init-db.sql"`]));
});

gulp.task('logs-db', () => {
    return gulp.src(__filename)
        .pipe(shell([`docker-compose logs db`]));
});

gulp.task('shutdown', () => {
    return gulp.src(__filename)
        .pipe(shell([`docker-compose down`]));
})
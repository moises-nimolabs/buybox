const gulp = require('gulp');
const shell = require('gulp-shell');

gulp.task('start-db', () => {
    return gulp.src(__filename)
        .pipe(shell([`docker-compose up -d db`]));
});

gulp.task('logs-db', () => {
    return gulp.src(__filename)
        .pipe(shell([`docker-compose logs db`]));
});
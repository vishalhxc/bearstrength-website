/// <binding AfterBuild='clean, minify, bootstrap, jquery' />
var gulp = require('gulp');
var sass = require('gulp-sass');
var clean = require('gulp-clean');

gulp.task("clean", function () {
    return gulp.src('wwwroot/js', { read: false })
        .pipe(clean());
});

gulp.task("bootstrap", function () {
    var streams = [];

    streams.push(
        gulp.src("node_modules/bootstrap/dist/js/bootstrap.min.js")
            .pipe(gulp.dest("wwwroot/js"))
    );

    streams.push(
        gulp.src("node_modules/bootstrap/dist/css/bootstrap.min.css")
            .pipe(gulp.dest("wwwroot/css"))
    );

    return merge(streams);
});


gulp.task("jquery", function () {
    return gulp.src("node_modules/jquery/dist/jquery.min.js")
        .pipe(gulp.dest("wwwroot/js"));
});

gulp.task("sass", function () {
    return gulp.src('Styles/Site.scss')
        .pipe(sass())
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task("default", gulp.series('clean', 'bootstrap', 'jquery', 'sass'))
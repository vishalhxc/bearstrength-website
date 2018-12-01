/// <binding AfterBuild='default' />
var gulp = require('gulp');
var sass = require('gulp-sass');
var minify = require('gulp-minify');
var cleanCss = require('gulp-clean-css');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');
var rimraf = require("rimraf");
var merge = require('merge-stream');

gulp.task("add-bootstrap", function () {
    var streams = [];

    streams.push(
        gulp.src('node_modules/bootstrap/dist/js/bootstrap.min.js')
            .pipe(gulp.dest('wwwroot/js'))
    );

    streams.push(
        gulp.src('node_modules/bootstrap/dist/css/bootstrap.min.css')
            .pipe(gulp.dest('wwwroot/css'))
    );

    return merge(streams);
});


gulp.task("add-jquery", function () {
    return gulp.src("node_modules/jquery/dist/jquery.min.js")
        .pipe(gulp.dest("wwwroot/js"));
});

gulp.task("compile-minify-sass", function () {
    return gulp.src('Styles/Site.scss')
        .pipe(sass())
        .pipe(cleanCss())
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task("minify-js", function () {
    return gulp.src('Scripts/*.js')
        .pipe(uglify())
        .pipe(gulp.dest('wwwroot/js'));
});

gulp.task("default", gulp.series('add-bootstrap', 'add-jquery', 'compile-minify-sass', 'minify-js'))
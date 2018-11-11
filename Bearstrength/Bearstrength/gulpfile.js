/// <binding AfterBuild='default' />
var gulp = require('gulp');
var sass = require('gulp-sass');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');
var rimraf = require("rimraf");
var merge = require('merge-stream');

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

gulp.task("default", gulp.series('bootstrap', 'jquery', 'sass'))
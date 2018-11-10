/// <binding AfterBuild='clean, minify, scripts' />
var gulp = require('gulp');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');
var rimraf = require("rimraf");
var merge = require('merge-stream');

gulp.task("minify", function () {

    var streams = [
        gulp.src(["wwwroot/js/*.js"])
            .pipe(uglify())
            .pipe(concat("site.min.js"))
            .pipe(gulp.dest("wwwroot/lib/site"))
    ];

    return merge(streams);
});

gulp.task("clean", function (cb) {
    return rimraf("wwwroot/vendor/", cb);
});

gulp.task("scripts", function () {

    // Dependency Dirs
    var deps = {
        "bootstrap": {
            "dist/css/bootstrap.min.css": "",
            "dist/js/bootstrap.min.js": ""
        },
        "jquery": {
            "dist/jquery.min.js": ""
        }
    };

    var streams = [];

    for (var prop in deps) {
        console.log("Prepping Scripts for: " + prop);
        for (var itemProp in deps[prop]) {
            streams.push(gulp.src("node_modules/" + prop + "/" + itemProp)
                .pipe(gulp.dest("wwwroot/vendor/" + prop + "/" + deps[prop][itemProp])));
        }
    }

    return merge(streams);

});



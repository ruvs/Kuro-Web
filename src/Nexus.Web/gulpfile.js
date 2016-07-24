/// <binding />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/
var scriptsSource = "./scripts/";
var scriptsDest = "./wwwroot";

//var sassSource = "./sass/";
//var sassDest = "./wwwroot/css";

var gulp = require('gulp'),
    Q = require('q'),
    rimraf = require('rimraf');

gulp.task('clean', function (cb) {
    return rimraf('./wwwroot/lib/', cb);
});

gulp.task('copy:lib', ['clean'], function () {
    var libs = [
        "@angular",
        "systemjs",
        "core-js",
        "zone.js",
        "reflect-metadata",
        "rxjs"
    ];

    var promises = [];

    libs.forEach(function (lib) {
        var defer = Q.defer();
        var pipeline = gulp
            .src('node_modules/' + lib + '/**/*')
            .pipe(gulp.dest('./wwwroot/lib/' + lib));

        pipeline.on('end', function () {
            defer.resolve();
        });
        promises.push(defer.promise);
    });

    return Q.all(promises);
});

gulp.task("html", function () {
    gulp.src(scriptsSource + "**/*.html")
        .pipe(gulp.dest(scriptsDest));
});


//gulp.task("sass", function () {
//    return gulp.src(sassSource + "MovieStyles.scss")
//    .pipe(sass().on("error", sass.logError))
//    .pipe(gulp.dest(sassDest));
//});

gulp.task("watch", function () {
    gulp.watch(scriptsSource + "**/*.html", ["html"]);
    //gulp.watch(sassSource + "**/*.scss", ["sass"]);
});

//gulp.task('default', function () {
//    // place code for your default task here
//});

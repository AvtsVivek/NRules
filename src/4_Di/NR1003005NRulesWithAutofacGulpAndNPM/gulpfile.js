const { series, src, dest } = require('gulp');
const del = require('del');

function clean(cb) {
    // body omitted
    cb();
}

function build(cb) {
    // body omitted
    cb();
}

function empty_wwwroot_directory(cb) {
    del('wwwroot/**', { force: false });
    cb();
}

function copy_jquery(cb) {
    src(['node_modules/jquery/dist/**',
        '!node_modules/jquery/dist/*.slim.*'])
        .pipe(dest('wwwroot/lib/jquery/dist/'));
    cb();
}

function copy_jquery_validation(cb) {
    src(['node_modules/jquery-validation/dist/**',
        '!node_modules/jquery-validation/dist/localization/**'])
        .pipe(dest('wwwroot/lib/jquery-validation/dist/'));
    cb();
}

function copy_jquery_validation_unobtrusive(cb) {
    src(['node_modules/jquery-validation-unobtrusive/dist/**'])
        .pipe(dest('wwwroot/lib/jquery-validation-unobtrusive/dist/'));
    cb();
}

function copy_bootstrap(cb) {
    src(['node_modules/bootstrap/dist/**',
        '!node_modules/bootstrap/dist/js/*esm*',
        '!node_modules/bootstrap/dist/css/*rtl*',
        '!node_modules/bootstrap/dist/css/*utilities*',
    ]).pipe(dest('wwwroot/lib/bootstrap/dist/'));
    cb();
}

function copy_rootfiles(cb) {
    src('rootfiles/**').pipe(dest('wwwroot/'));
    cb();
}

function trial_console_log(cb) {
    console.log('Just a trial message');
    cb();
}

exports.build = build;
exports.empty_wwwroot_directory = empty_wwwroot_directory;
exports.copy_jquery = copy_jquery;
exports.copy_jquery_validation = copy_jquery_validation;
exports.copy_jquery_validation_unobtrusive = copy_jquery_validation_unobtrusive;
exports.copy_bootstrap = copy_bootstrap;
exports.copy_rootfiles = copy_rootfiles;
exports.trial_console_log = trial_console_log;

exports.default = series(clean, build, copy_rootfiles, copy_jquery,
    copy_jquery_validation, copy_jquery_validation_unobtrusive,
    copy_bootstrap, trial_console_log);

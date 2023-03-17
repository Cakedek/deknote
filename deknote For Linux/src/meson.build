deknote_sources = [
  'main.vala',
  'application.vala',
  'window.vala',
]

deknote_deps = [
  dependency('gtk4'),
  dependency('libadwaita-1'),
]

deknote_sources += gnome.compile_resources('deknote-resources',
  'deknote.gresource.xml',
  c_name: 'deknote'
)

executable('deknote', deknote_sources,
  dependencies: deknote_deps,
       install: true,
)

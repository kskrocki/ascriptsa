task :load_yaml_configuration do
  Dir.glob("build/configuration/*.yaml").each do|file|
    configatron.configure_from_yaml file
  end
end

Rake::Task[:load_yaml_configuration].invoke

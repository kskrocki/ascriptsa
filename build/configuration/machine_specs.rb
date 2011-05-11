task :configure_mspec do
  configs = 
  {
    :specs =>
    {
      :runner_options => ["-x","example"],
      :assemblies => dynamic{Dir.glob("#{configatron.artifacts_dir}/*specs.dll")},
    }
  }
  configatron.configure_from_hash configs
end

Rake::Task['configure_mspec'].invoke



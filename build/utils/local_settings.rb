class LocalSettings
  attr_reader :settings
  

  def [](setting)
    @settings[setting]
  end

  def initialize()
    @settings = create_settings_dictionary
  end

end

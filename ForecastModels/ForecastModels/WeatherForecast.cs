// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: protos/WeatherForecast.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Forecast {

  /// <summary>Holder for reflection information generated from protos/WeatherForecast.proto</summary>
  public static partial class WeatherForecastReflection {

    #region Descriptor
    /// <summary>File descriptor for protos/WeatherForecast.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static WeatherForecastReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Chxwcm90b3MvV2VhdGhlckZvcmVjYXN0LnByb3RvEglmb3JlY2FzdHMaH2dv",
            "b2dsZS9wcm90b2J1Zi90aW1lc3RhbXAucHJvdG8i2wEKD1dlYXRoZXJGb3Jl",
            "Y2FzdBIwCgxDcmVhdGlvblRpbWUYASABKAsyGi5nb29nbGUucHJvdG9idWYu",
            "VGltZXN0YW1wEigKBERhdGUYAiABKAsyGi5nb29nbGUucHJvdG9idWYuVGlt",
            "ZXN0YW1wEgwKBENpdHkYAyABKAkSIwoHQ29udGV4dBgEIAEoDjISLmZvcmVj",
            "YXN0cy5Db250ZXh0EhQKDFRlbXBlcmF0dXJlQxgFIAEoBRIjCgdTdW1tYXJ5",
            "GAYgASgOMhIuZm9yZWNhc3RzLlN1bW1hcnkqIQoHQ29udGV4dBIJCgVJblN1",
            "bhAAEgsKB0luU2hhZGUQASqBAQoHU3VtbWFyeRIMCghGcmVlemluZxAAEgsK",
            "B0JyYWNpbmcQARIKCgZDaGlsbHkQAhIICgRDb29sEAMSCAoETWlsZBAEEggK",
            "BFdhcm0QBRIJCgVCYWxteRAGEgcKA0hvdBAHEg4KClN3ZWx0ZXJpbmcQCBIN",
            "CglTY29yY2hpbmcQCUILqgIIRm9yZWNhc3RiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Forecast.Context), typeof(global::Forecast.Summary), }, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Forecast.WeatherForecast), global::Forecast.WeatherForecast.Parser, new[]{ "CreationTime", "Date", "City", "Context", "TemperatureC", "Summary" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  /// <summary>
  /// Forecast context
  /// </summary>
  public enum Context {
    [pbr::OriginalName("InSun")] InSun = 0,
    [pbr::OriginalName("InShade")] InShade = 1,
  }

  /// <summary>
  /// Summary of conditions
  /// </summary>
  public enum Summary {
    [pbr::OriginalName("Freezing")] Freezing = 0,
    [pbr::OriginalName("Bracing")] Bracing = 1,
    [pbr::OriginalName("Chilly")] Chilly = 2,
    [pbr::OriginalName("Cool")] Cool = 3,
    [pbr::OriginalName("Mild")] Mild = 4,
    [pbr::OriginalName("Warm")] Warm = 5,
    [pbr::OriginalName("Balmy")] Balmy = 6,
    [pbr::OriginalName("Hot")] Hot = 7,
    [pbr::OriginalName("Sweltering")] Sweltering = 8,
    [pbr::OriginalName("Scorching")] Scorching = 9,
  }

  #endregion

  #region Messages
  /// <summary>
  /// [START messages]
  /// A weather forecast with date, temp, summary
  /// </summary>
  public sealed partial class WeatherForecast : pb::IMessage<WeatherForecast> {
    private static readonly pb::MessageParser<WeatherForecast> _parser = new pb::MessageParser<WeatherForecast>(() => new WeatherForecast());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<WeatherForecast> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Forecast.WeatherForecastReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WeatherForecast() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WeatherForecast(WeatherForecast other) : this() {
      creationTime_ = other.creationTime_ != null ? other.creationTime_.Clone() : null;
      date_ = other.date_ != null ? other.date_.Clone() : null;
      city_ = other.city_;
      context_ = other.context_;
      temperatureC_ = other.temperatureC_;
      summary_ = other.summary_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WeatherForecast Clone() {
      return new WeatherForecast(this);
    }

    /// <summary>Field number for the "CreationTime" field.</summary>
    public const int CreationTimeFieldNumber = 1;
    private global::Google.Protobuf.WellKnownTypes.Timestamp creationTime_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp CreationTime {
      get { return creationTime_; }
      set {
        creationTime_ = value;
      }
    }

    /// <summary>Field number for the "Date" field.</summary>
    public const int DateFieldNumber = 2;
    private global::Google.Protobuf.WellKnownTypes.Timestamp date_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp Date {
      get { return date_; }
      set {
        date_ = value;
      }
    }

    /// <summary>Field number for the "City" field.</summary>
    public const int CityFieldNumber = 3;
    private string city_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string City {
      get { return city_; }
      set {
        city_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Context" field.</summary>
    public const int ContextFieldNumber = 4;
    private global::Forecast.Context context_ = global::Forecast.Context.InSun;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Forecast.Context Context {
      get { return context_; }
      set {
        context_ = value;
      }
    }

    /// <summary>Field number for the "TemperatureC" field.</summary>
    public const int TemperatureCFieldNumber = 5;
    private int temperatureC_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int TemperatureC {
      get { return temperatureC_; }
      set {
        temperatureC_ = value;
      }
    }

    /// <summary>Field number for the "Summary" field.</summary>
    public const int SummaryFieldNumber = 6;
    private global::Forecast.Summary summary_ = global::Forecast.Summary.Freezing;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Forecast.Summary Summary {
      get { return summary_; }
      set {
        summary_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as WeatherForecast);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(WeatherForecast other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(CreationTime, other.CreationTime)) return false;
      if (!object.Equals(Date, other.Date)) return false;
      if (City != other.City) return false;
      if (Context != other.Context) return false;
      if (TemperatureC != other.TemperatureC) return false;
      if (Summary != other.Summary) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (creationTime_ != null) hash ^= CreationTime.GetHashCode();
      if (date_ != null) hash ^= Date.GetHashCode();
      if (City.Length != 0) hash ^= City.GetHashCode();
      if (Context != global::Forecast.Context.InSun) hash ^= Context.GetHashCode();
      if (TemperatureC != 0) hash ^= TemperatureC.GetHashCode();
      if (Summary != global::Forecast.Summary.Freezing) hash ^= Summary.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (creationTime_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(CreationTime);
      }
      if (date_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Date);
      }
      if (City.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(City);
      }
      if (Context != global::Forecast.Context.InSun) {
        output.WriteRawTag(32);
        output.WriteEnum((int) Context);
      }
      if (TemperatureC != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(TemperatureC);
      }
      if (Summary != global::Forecast.Summary.Freezing) {
        output.WriteRawTag(48);
        output.WriteEnum((int) Summary);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (creationTime_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CreationTime);
      }
      if (date_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Date);
      }
      if (City.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(City);
      }
      if (Context != global::Forecast.Context.InSun) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Context);
      }
      if (TemperatureC != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(TemperatureC);
      }
      if (Summary != global::Forecast.Summary.Freezing) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Summary);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(WeatherForecast other) {
      if (other == null) {
        return;
      }
      if (other.creationTime_ != null) {
        if (creationTime_ == null) {
          CreationTime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        CreationTime.MergeFrom(other.CreationTime);
      }
      if (other.date_ != null) {
        if (date_ == null) {
          Date = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        Date.MergeFrom(other.Date);
      }
      if (other.City.Length != 0) {
        City = other.City;
      }
      if (other.Context != global::Forecast.Context.InSun) {
        Context = other.Context;
      }
      if (other.TemperatureC != 0) {
        TemperatureC = other.TemperatureC;
      }
      if (other.Summary != global::Forecast.Summary.Freezing) {
        Summary = other.Summary;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (creationTime_ == null) {
              CreationTime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(CreationTime);
            break;
          }
          case 18: {
            if (date_ == null) {
              Date = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(Date);
            break;
          }
          case 26: {
            City = input.ReadString();
            break;
          }
          case 32: {
            Context = (global::Forecast.Context) input.ReadEnum();
            break;
          }
          case 40: {
            TemperatureC = input.ReadInt32();
            break;
          }
          case 48: {
            Summary = (global::Forecast.Summary) input.ReadEnum();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code

﻿// Copyright © 2015 - Present RealDimensions Software, LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
//
// You may obtain a copy of the License at
//
// 	http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace chocolatey.package.validator.infrastructure.app.rules
{
    using System.Linq;
    using infrastructure.rules;
    using NuGet;

    public class BinariesAreIncludedNote : BasePackageRule
    {
        public override string ValidationFailureMessage { get { return
@"Binary files (.exe, .msi, .zip) have been included. The reviewer will ensure the maintainers have distribution rights. [More...](https://github.com/chocolatey/package-validator/wiki/BinariesIncluded)";
        }
        }

        public override PackageValidationOutput is_valid(IPackage package)
        {
            return !package.GetFiles().or_empty_list_if_null().Any(
                f =>
                f.Path.to_lower().EndsWith(".exe") ||
                f.Path.to_lower().EndsWith(".msi") ||
                f.Path.to_lower().EndsWith(".dll") ||
                f.Path.to_lower().EndsWith(".zip")
                );
        }
    }
}
